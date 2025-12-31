-- =====================================================
-- PROJET POS RESTO
-- Base de donnees
-- =====================================================
    
-- Creer la base de donnees
CREATE DATABASE posresto 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

-- Supprimer l'utilisateur s'il existe
DROP USER IF EXISTS 'pos_resto_admin'@'localhost';

-- Creer l'utilisateur administrateur
CREATE USER 'pos_resto_admin'@'localhost' IDENTIFIED BY 'groupabb';

-- Attribution des droits sur la base posresto
GRANT ALL PRIVILEGES ON posresto.* TO 'pos_resto_admin'@'localhost';
FLUSH PRIVILEGES;

-- Utiliser la base
USE posresto;

-- =====================================================
-- TABLES
-- =====================================================

-- TABLE USERS
CREATE TABLE Users
(
    user_id  INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(100)       NOT NULL,
    role     ENUM('admin', 'staff', 'user') DEFAULT 'user' NOT NULL
);

-- TABLE MENUS
CREATE TABLE Menus
(
    menu_id        INT AUTO_INCREMENT PRIMARY KEY,
    name           VARCHAR(100)   NOT NULL,
    category       ENUM('plats', 'boissons', 'desserts'),
    stock_quantity INT DEFAULT 0,
    unit_price     DECIMAL(10, 2) NOT NULL,
    description    VARCHAR(255),
    CONSTRAINT chk_stock CHECK (stock_quantity >= 0)
);

-- TABLE CLIENTS
CREATE TABLE Clients
(
    client_id   INT AUTO_INCREMENT PRIMARY KEY,
    last_name   VARCHAR(50) NOT NULL,
    first_name  VARCHAR(50) NOT NULL,
    gender      ENUM('M', 'F'),
    phone       VARCHAR(20),
    email       VARCHAR(100),
    debt_amount DECIMAL(10, 2) DEFAULT 0,
    CONSTRAINT chk_debt CHECK (debt_amount >= 0)
);

-- TABLE ORDERS
CREATE TABLE Orders
(
    order_id   INT AUTO_INCREMENT PRIMARY KEY,
    menu_id    INT NOT NULL,
    client_id  INT NOT NULL,
    quantity   INT NOT NULL,
    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status ENUM('en cours', 'terminee', 'annulee') DEFAULT 'en cours',
    CONSTRAINT fk_order_menu FOREIGN KEY (menu_id) REFERENCES Menus (menu_id),
    CONSTRAINT fk_order_client FOREIGN KEY (client_id) REFERENCES Clients (client_id),
    CONSTRAINT chk_qty CHECK (quantity > 0)
);

-- TABLE PAYMENTS
CREATE TABLE Payments
(
    payment_id   INT AUTO_INCREMENT PRIMARY KEY,
    order_id     INT    NOT NULL,
    amount       DECIMAL(10, 2) NOT NULL,
    payment_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    payment_mode ENUM('cash', 'card', 'cheque'),
    CONSTRAINT fk_payment_order FOREIGN KEY (order_id) REFERENCES Orders (order_id),
    CONSTRAINT chk_amount CHECK (amount >= 0)
);

-- =====================================================
-- TRIGGERS
-- =====================================================

DELIMITER //

-- Trigger 1 : Gestion automatique du stock
CREATE TRIGGER trg_process_order_stock
    BEFORE INSERT
    ON Orders
    FOR EACH ROW
BEGIN
    DECLARE v_current_stock INT;

    SELECT stock_quantity
    INTO v_current_stock
    FROM Menus
    WHERE menu_id = NEW.menu_id;

    IF v_current_stock < NEW.quantity THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Erreur : Stock insuffisant pour ce produit !';
    ELSE
    UPDATE Menus
    SET stock_quantity = stock_quantity - NEW.quantity
    WHERE menu_id = NEW.menu_id;
END IF;
END
//

-- Trigger 2 : Mise a jour de la dette client apres une commande
CREATE TRIGGER trg_update_client_debt_after_order
    AFTER INSERT
    ON Orders
    FOR EACH ROW
BEGIN
    DECLARE v_total_price DECIMAL(10,2);
    
    -- Calculer le total de la commande
    SELECT unit_price * NEW.quantity
    INTO v_total_price
    FROM Menus
    WHERE menu_id = NEW.menu_id;

    -- Augmenter la dette du client du montant de la commande
    UPDATE Clients
    SET debt_amount = debt_amount + v_total_price
    WHERE client_id = NEW.client_id;

    -- Securite : Empecher une dette negative (au cas ou)
    UPDATE Clients
    SET debt_amount = 0
    WHERE client_id = NEW.client_id
      AND debt_amount < 0;
END //

-- Trigger 3 : Mise a jour de la dette client apres paiement
CREATE TRIGGER trg_update_client_debt_after_payment
    AFTER INSERT
    ON Payments
    FOR EACH ROW
BEGIN
    DECLARE v_total_price DECIMAL(10,2);
    DECLARE v_client_id INT;
    
    -- On recupere les details de la commande liee au paiement
    SELECT o.client_id, (m.unit_price * o.quantity)
    INTO v_client_id, v_total_price
    FROM Orders o
             JOIN Menus m ON o.menu_id = m.menu_id
    WHERE o.order_id = NEW.order_id;

    -- On reduit la dette : Montant paye est deduit de la dette
    UPDATE Clients
    SET debt_amount = debt_amount - NEW.amount
    WHERE client_id = v_client_id;

    -- Securite : Empecher une dette negative
    UPDATE Clients
    SET debt_amount = 0
    WHERE client_id = v_client_id
      AND debt_amount < 0;
END //

-- Trigger 4 : Restaurer le stock et ajuster la dette si une commande est annulee
CREATE TRIGGER trg_restore_stock_on_cancel
    BEFORE UPDATE
    ON Orders
    FOR EACH ROW
BEGIN
    -- Si le statut passe a 'annulee'
    IF OLD.status != 'annulee' AND NEW.status = 'annulee' THEN
        -- Restaurer le stock
    UPDATE Menus
    SET stock_quantity = stock_quantity + OLD.quantity
    WHERE menu_id = OLD.menu_id;

    -- Reduire la dette du client (puisque la commande est annulee)
    UPDATE Clients c
        JOIN Menus m ON OLD.menu_id = m.menu_id
        SET c.debt_amount = c.debt_amount - (m.unit_price * OLD.quantity)
    WHERE c.client_id = OLD.client_id;

    -- Securite : Empecher une dette negative
    UPDATE Clients
    SET debt_amount = 0
    WHERE client_id = OLD.client_id
      AND debt_amount < 0;
END IF;
END //

DELIMITER ;

-- =====================================================
-- INDEX POUR PERFORMANCES
-- =====================================================

CREATE INDEX idx_orders_client ON Orders(client_id);
CREATE INDEX idx_orders_menu ON Orders(menu_id);
CREATE INDEX idx_orders_date ON Orders(order_date);
CREATE INDEX idx_orders_status ON Orders(status);
CREATE INDEX idx_payments_order ON Payments(order_id);
CREATE INDEX idx_payments_date ON Payments(payment_date);
CREATE INDEX idx_clients_name ON Clients(last_name, first_name);
CREATE INDEX idx_menus_category ON Menus(category);

-- =====================================================
-- DONNEES DE TEST
-- =====================================================

-- Inserer des utilisateurs
INSERT INTO Users (username, password, role)
VALUES ('Servilus_2509', 'admin123', 'admin'),
       ('Albikendy', 'jean123', 'staff'),
       ('Blemy', 'jblemy123', 'staff'),
       ('User_test', 'user123', 'user');

-- Inserer des menus
INSERT INTO Menus (name, category, stock_quantity, unit_price, description)
VALUES ('Poulet Grille', 'plats', 50, 250.00, 'Poulet marine grille avec legumes'),
       ('Pizza Margherita', 'plats', 30, 300.00, 'Pizza classique avec fromage et tomate'),
       ('Coca-Cola', 'boissons', 100, 50.00, 'Boisson gazeuse'),
       ('Jus d''orange', 'boissons', 80, 75.00, 'Jus naturel presse'),
       ('Tiramisu', 'desserts', 20, 150.00, 'Dessert italien au cafe');

-- Inserer des clients
INSERT INTO Clients (last_name, first_name, gender, phone, email, debt_amount)
VALUES ('SERVILUS', 'Bendy', 'M', '41705257', 'bendyservilus@gmail.com', 0),
       ('JOSEPH', 'Blemy', 'M', '35359939', 'jblemy@gmail.com', 0),
       ('JEAN', 'Albikendy', 'M', '35416402', 'jeanalbikendy@gmail.com', 0);
