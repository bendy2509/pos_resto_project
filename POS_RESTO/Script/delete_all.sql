-- 1. Desactiver les verifications de cles etrangeres pour eviter les erreurs de dependance
SET FOREIGN_KEY_CHECKS = 0;

-- 2. Supprimer les Tables (MySQL supprime les triggers associes automatiquement)
DROP TABLE IF EXISTS Payments;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Clients;
DROP TABLE IF EXISTS Menus;
DROP TABLE IF EXISTS Users;

-- 3. Reactiver les verifications de cles etrangeres
SET FOREIGN_KEY_CHECKS = 1;

-- Note : En MySQL, les Triggers sont attaches à la table. 
-- Quand vous faites "DROP TABLE", les triggers disparaissent avec elle