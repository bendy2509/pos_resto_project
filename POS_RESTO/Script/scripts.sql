-- =====================================================
-- PROJET POS RESTO
-- Base de donnees
-- =====================================================

-- 1. Supprimer la base si elle existe
DROP
DATABASE IF EXISTS posresto;

-- 2. Creer la base de donnees
CREATE
DATABASE posresto 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

-- 3. Supprimer l'utilisateur s'il existe
DROP
USER IF EXISTS 'pos_resto_admin'@'localhost';

-- 4. Creer l'utilisateur administrateur
CREATE
USER 'pos_resto_admin'@'localhost' IDENTIFIED BY 'groupabb';

-- 5. Attribution des droits sur la base posresto
GRANT ALL PRIVILEGES ON posresto.* TO
'pos_resto_admin'@'localhost';
FLUSH
PRIVILEGES;

-- 6. Utiliser la base
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
    CONSTRAINT fk_order_menu FOREIGN KEY (menu_id) REFERENCES Menus (menu_id),
    CONSTRAINT fk_order_client FOREIGN KEY (client_id) REFERENCES Clients (client_id),
    CONSTRAINT chk_qty CHECK (quantity > 0)
);

-- TABLE PAYMENTS
CREATE TABLE Payments
(
    payment_id   INT AUTO_INCREMENT PRIMARY KEY,
    order_id     INT UNIQUE     NOT NULL,
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

-- Trigger 2 : Mise a jour de la dette client apres paiement
CREATE TRIGGER trg_update_client_debt
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

    -- On ajuste la dette : (Prix Total - Montant paye)
    UPDATE Clients
    SET debt_amount = debt_amount + (v_total_price - NEW.amount)
    WHERE client_id = v_client_id;

    -- Securite : Empecher une dette negative
    UPDATE Clients
    SET debt_amount = 0
    WHERE client_id = v_client_id
      AND debt_amount < 0;
END //

DELIMITER ;

-- =====================================================
-- DONNEES DE TEST
-- =====================================================

-- Inserer des utilisateurs
INSERT INTO Users (username, password, role)
VALUES ('admin', 'admin123', 'admin'),
       ('serveur', 'serveur123', 'staff'),
       ('client', 'client123', 'user');

-- Inserer des menus
INSERT INTO Menus (name, category, stock_quantity, unit_price, description)
VALUES ('Poulet Grille', 'plats', 50, 250.00, 'Poulet marine grille avec legumes'),
       ('Pizza Margherita', 'plats', 30, 300.00, 'Pizza classique avec fromage et tomate'),
       ('Coca-Cola', 'boissons', 100, 50.00, 'Boisson gazeuse'),
       ('Jus d''orange', 'boissons', 80, 75.00, 'Jus naturel presse'),
       ('Tiramisu', 'desserts', 20, 150.00, 'Dessert italien au cafe');

-- Inserer des clients
INSERT INTO Clients (last_name, first_name, gender, phone, email)
VALUES ('Dupont', 'Jean', 'M', '41705257', 'jean@example.com'),
       ('Martin', 'Marie', 'F', '41705259', 'marie@example.com'),
       ('Pierre', 'Jacques', 'M', '41705258', 'jacques@example.com');

-- =====================================================
-- VERIFICATION
-- =====================================================

-- Afficher toutes les tables
SHOW
TABLES;

-- Verifier les donnees
SELECT 'Users' as TableName, COUNT(*) as Count
FROM Users
UNION ALL
SELECT 'Menus', COUNT(*)
FROM Menus
UNION ALL
SELECT 'Clients', COUNT(*)
FROM Clients
UNION ALL
SELECT 'Orders', COUNT(*)
FROM Orders
UNION ALL
SELECT 'Payments', COUNT(*)
FROM Payments;

-- Verifier les triggers
SHOW
TRIGGERS FROM posresto;