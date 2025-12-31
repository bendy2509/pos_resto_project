==============================================
PROJET POS RESTO - SYSTEME DE GESTION
==============================================

EQUIPE DE DEVELOPPEMENT
=======================
N°  NOM               PRENOM
1.  SERVILUS          Bendy
2.  JOSEPH            Blemy
3.  ALBIKENDY         Jean

SUPERVISEUR: Jaures PIERRE
COURS: Bases de Données / Développement C# / .NET
VERSION: 1.0.0

DESCRIPTION GENERALE
====================
Système de Point de Vente (POS) pour restaurant développé en C# avec Windows Forms
et MySQL. L'application permet la gestion complète des opérations d'un restaurant
avec suivi en temps réel des stocks, dettes clients et ventes.

TECHNOLOGIES UTILISEES
======================
- Langage: C# (.NET 9.0)
- Interface: Windows Forms
- Base de données: MySQL 8.0+
- Connecteur: MySql.Data (v9.5.0+)
- IDE: JetBrains Rider 2025.3.1
- Version: Application Desktop Windows
- GitHub Copilot : Pour les commentaires (plugins Rider)

MOYENS DE CONNEXION A LA BASE DE DONNEES
========================================

CONFIGURATION PAR DEFAUT:
-------------------------
Serveur: localhost
Port: 3310
Base de données: posresto
Utilisateur: pos_resto_admin
Mot de passe: groupabb

CHAINE DE CONNEXION (DatabaseConfig.cs):
----------------------------------------
string connString = $"Server={host};Port={port};Database={database};Uid={user};Pwd={password};";

UTILISATEURS PAR DEFAUT:
------------------------
1. Administrateur:
   - Username: Servilus_2509
   - Password: admin123
   - Rôle: admin (accès complet)

FONCTIONNALITES IMPLEMENTEES
============================

1. GESTION DES UTILISATEURS (COMPLET)
   -----------------------------------
   - Système d'authentification avec 3 rôles
   - Interface adaptée selon le rôle
   - Messages d'erreur en français

2. GESTION DES MENUS (COMPLET)
   ----------------------------
   - CRUD complet (Create, Read, Update, Delete)
   - Catégories: plats, boissons, desserts
   - Gestion des stocks en temps réel
   - Validation des prix et quantités
   - Recherche par nom/catégorie

3. GESTION DES CLIENTS (COMPLET)
   ------------------------------
   - Fiche client complète avec validation
   - Validation email
   - Validation phone non implementer
   - Gestion automatique de la dette
   - Recherche multicritère
   - Historique des commandes par client

4. GESTION DES COMMANDES (COMPLET)
   --------------------------------
   - Interface intuitive type "panier"
   - Validation du stock en temps réel
   - Calcul automatique des totaux
   - Sélection client avec ComboBox
   - Statut des commandes (en cours/terminée/annulée)

5. GESTION DES PAIEMENTS (COMPLET)
   --------------------------------
   - Paiements multiples par commande
   - Modes: cash, card, cheque
   - Suivi des montants payés/restants
   - Historique des transactions
   - Validation des montants

6. AUTOMATISATIONS VIA TRIGGERS (COMPLET)
   ---------------------------------------
   - Gestion automatique du stock
   - Mise à jour automatique de la dette
   - Restauration stock annulation
   - Prévention dettes négatives

CONTRAINTES GERÉES DANS LE SYSTEME
==================================

1. CONTRAINTES D'INTEGRITE (BASE DE DONNEES)
   ------------------------------------------
   a) Contraintes de clés:
      - PRIMARY KEY sur toutes les tables
      - FOREIGN KEY avec ON DELETE restrictions
      - UNIQUE sur username (Users)

   b) Contraintes de domaine:
      - CHECK stock_quantity >= 0 (Menus)
      - CHECK debt_amount >= 0 (Clients)
      - CHECK quantity > 0 (Orders)
      - CHECK amount >= 0 (Payments)
      - ENUM pour les catégories et rôles

2. CONTRAINTES METIER (APPLICATION)
   ---------------------------------
   a) Validation des données:
      - Email: format valide (regex)
      - Téléphone: format haïtien (non pas ete implementer)
      - Prix: > 0 et limites raisonnables
      - Quantités: entiers positifs

   b) Règles métier:
      - Stock insuffisant → Commande impossible
      - Paiement > Dette → Avertissement
      - Commande annulée → Restauration stock et ajustement dette
      - Client obligatoire pour commande

3. CONTRAINTES D'INTERFACE
   ------------------------
   a) Expérience utilisateur:
      - Messages d'erreur en français
      - Validation en temps réel
      - Feedback visuel (couleurs, ErrorProvider)
      - Interface intuitive mais peu responsive

   b) Sécurité:
      - Champs obligatoires marqués *
      - Confirmation avant suppression
      - Protection basique injection SQL

ARCHITECTURE DE L'APPLICATION
=============================

POS_RESTO/
├── Configuration/
│   └── DatabaseConfig.cs      # Configuration connexion DB
├── Data/ (Couche d'accès aux données)
│   ├── DatabaseHelper.cs      # Méthodes génériques DB
│   ├── ClientDao.cs           # Opérations CRUD Clients
│   ├── MenuDao.cs             # Opérations CRUD Menus
│   ├── OrderDao.cs            # Gestion Commandes
│   ├── PaymentDao.cs          # Gestion Paiements
│   └── UserDao.cs             # Authentification
├── Forms/ (Interfaces - Windows Forms)
│   ├── MainForm.cs            # Formulaire principal avec menu
│   ├── ClientForm.cs          # Formulaire Client
│   ├── MenuForm.cs            # Formulaire Menu
│   ├── OrderForm.cs           # Formulaire Commande
│   ├── PaymentForm.cs         # Formulaire Paiement
│   ├── LoginForm.cs           # Formulaire Connexion
│   └── ReportForm.cs          # Formulaire Rapports
├── Models/ (Modèles métier)
│   ├── Client.cs              # Modèle Client
│   ├── Menu.cs                # Modèle Menu
│   ├── Order.cs               # Modèle Commande
│   ├── OrderItem.cs           # Élément de commande
│   ├── Payment.cs             # Modèle Paiement
│   └── User.cs                # Modèle Utilisateur
├── Utilities/
│   ├── ValidationHelper.cs    # Validation données
│   ├── ExtensionMethods.cs    # Méthodes d'extension
│   └── Logger.cs              # Journalisation
├── Views/ (UserControls pour le formulaire principal)
│   ├── DashboardUserControl.cs
│   ├── ClientsUserControl.cs
│   ├── MenusUserControl.cs
│   ├── OrdersUserControl.cs
│   ├── PaymentsUserControl.cs
│   ├── ReportsUserControl.cs
├── Services/
│   ├── OrderService.cs
├── Script/
│   ├── scripts.sql  # Le script de la BD
└── Program.cs       # Point d'entrée

PATTERN ARCHITECTURAL:
----------------------
- Architecture 3-tier (Présentation, Logique, Données)
- Pattern DAO (Data Access Object)
- Séparation des responsabilités
- Code modulaire et réutilisable

TRIGGERS MYSQL IMPLEMENTES
==========================

1. trg_process_order_stock (BEFORE INSERT Orders)
   -------------------------------------------------
   Objectif: Gérer automatiquement le stock
   Logique:
   - Vérifie si stock suffisant
   - Décrémente le stock si OK
   - Lance erreur si stock insuffisant

2. trg_update_client_debt_after_order (AFTER INSERT Orders)
   ---------------------------------------------------------
   Objectif: Mettre à jour la dette après commande
   Logique:
   - Calcule total commande (prix × quantité)
   - Augmente dette client de ce montant
   - Empêche dette négative

3. trg_update_client_debt_after_payment (AFTER INSERT Payments)
   -------------------------------------------------------------
   Objectif: Ajuster dette après paiement
   Logique:
   - Réduit dette du montant payé
   - Empêche dette négative

4. trg_restore_stock_on_cancel (BEFORE UPDATE Orders)
   ---------------------------------------------------
   Objectif: Gérer annulations
   Logique:
   - Si statut → "annulee"
   - Restaure le stock
   - Réduit la dette correspondante

VALIDATIONS IMPLEMENTEES
========================

1. VALIDATION COTE CLIENT (Windows Forms)
   ---------------------------------------
   - ErrorProvider pour feedback visuel
   - Validating events sur TextBox
   - MessageBox pour erreurs critiques
   - Contrôles désactivés si non valides

2. VALIDATION COTE SERVEUR (C# DAO)
   ---------------------------------
   - Vérification format email
   - Validation téléphone haïtien
   - Contrôle des montants
   - Gestion des exceptions

3. VALIDATION BASE DE DONNEES (MySQL)
   -----------------------------------
   - Constraints CHECK
   - Triggers pour règles métier
   - Types ENUM pour valeurs fixes
   - FOREIGN KEY pour intégrité

DIFFICULTES RENCONTREES ET SOLUTIONS
=====================================

1. PROBLEME: Gestion dette client après paiements multiples
   SOLUTION: Triggers séparés pour commande et paiement

2. PROBLEME: Interface panier intuitive
   SOLUTION: ListBox avec objets CartItem et calcul auto
   
3. PROBLEME: Performance chargement données
   SOLUTION: Index MySQL et pagination implicite
   
4. PROBLEME: Gestion erreurs utilisateur
   SOLUTION: Messages français + ErrorProvider

AMELIORATIONS FUTURES POSSIBLES
===============================

1. COURT TERME:
   - Impression tickets
   - Tableau de bord statistiques
   - Gestion des taxes
   - Backup automatique

2. MOYEN TERME:
   - Application mobile serveurs
   - Scanner code-barres
   - Intégration paiement mobile
   - Gestion des tables

3. LONG TERME:
   - Version web
   - Application livraison
   - Analyse prédictive
   - API REST

DOCUMENTATION TECHNIQUE
=======================

FICHIERS FOURNIS:
-----------------
1. README.txt (ce fichier)
2. scripts.sql (script base de données)
3. Code source complet

CONCLUSION
==========

Le système POS RESTO répond aux exigences d'un système de gestion de restaurant avec:

✓ Gestion complète stock et commandes
✓ Système dette client automatisé
✓ Interface intuitive en français
✓ Validation robuste des données
✓ Architecture modulaire et extensible
✓ Documentation complète

L'application démontre la maîtrise de:
- Développement C# avec Windows Forms
- Conception base de données MySQL
- Programmation avec triggers
- Validation données multi-niveaux
- Gestion projet en équipe

CONTACTS EQUIPE
===============
- Bendy SERVILUS: bendyservilus@student.ueh.edu.ht
- Blemy JOSEPH: blemy.joseph@student.ueh.edu.ht
- Jean ALBIKENDY: albikendy.jean@student.ueh.edu.ht

DATE DE LIVRAISON: 31/12/2025
DERNIERE MODIFICATION: 31/12/2025

© 2024 - Équipe POS RESTO - Tous droits réservés.