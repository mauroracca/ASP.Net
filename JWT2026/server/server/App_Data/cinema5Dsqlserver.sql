-- =========================================
-- NOME DATABASE: cinema5d
-- =========================================
-- =========================================
-- TABELLA: categorie
-- =========================================
CREATE TABLE categorie (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nome_categoria VARCHAR(50) NOT NULL,
    descrizione VARCHAR(MAX)
);
GO

-- =========================================
-- TABELLA: registi
-- =========================================
CREATE TABLE registi (
    id_regista INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    cognome VARCHAR(50) NOT NULL,
    data_nascita DATE,
    nazionalita VARCHAR(50),
    numero_film_diretti INT
);
GO

-- =========================================
-- TABELLA: film (CON INCASSO)
-- =========================================
CREATE TABLE film (
    id_film INT IDENTITY(1,1) PRIMARY KEY,
    titolo VARCHAR(100) NOT NULL,
    anno INT,
    durata INT,
    trama VARCHAR(MAX),
    locandina VARCHAR(500) NOT NULL,
    incasso DECIMAL(15,2) NOT NULL,
    id_regista INT,
    id_categoria INT,

    CONSTRAINT FK_film_regista 
        FOREIGN KEY (id_regista) REFERENCES registi(id_regista),

    CONSTRAINT FK_film_categoria 
        FOREIGN KEY (id_categoria) REFERENCES categorie(id_categoria)
);
GO

-- =========================================
-- INSERT: categorie
-- =========================================
SET IDENTITY_INSERT categorie ON;

INSERT INTO categorie (id_categoria, nome_categoria, descrizione) VALUES
(1, 'Fantascienza', 'Film ambientati nel futuro o con tecnologie avanzate'),
(2, 'Azione', 'Film con molte scene dinamiche e spettacolari'),
(3, 'Drammatico', 'Film con forte componente emotiva e narrativa'),
(4, 'Avventura', 'Film basati su viaggi e imprese'),
(5, 'Thriller', 'Film ricchi di suspense e tensione');

SET IDENTITY_INSERT categorie OFF;
GO

-- =========================================
-- INSERT: registi
-- =========================================
SET IDENTITY_INSERT registi ON;

INSERT INTO registi (id_regista, nome, cognome, data_nascita, nazionalita, numero_film_diretti) VALUES
(1, 'Steven', 'Spielberg', '1946-12-18', 'USA', 34),
(2, 'Christopher', 'Nolan', '1970-07-30', 'Regno Unito', 12),
(3, 'Quentin', 'Tarantino', '1963-03-27', 'USA', 10),
(4, 'James', 'Cameron', '1954-08-16', 'Canada', 9),
(5, 'Ridley', 'Scott', '1937-11-30', 'Regno Unito', 28);

SET IDENTITY_INSERT registi OFF;
GO

-- =========================================
-- INSERT: film (CON INCASSO)
-- =========================================
SET IDENTITY_INSERT film ON;

INSERT INTO film 
(id_film, titolo, anno, durata, trama, locandina, incasso, id_regista, id_categoria) 
VALUES
(1, 'Jurassic Park', 1993, 127, 'Un parco tematico popolato da dinosauri clonati sfugge al controllo.', 'https://shop.laboratoriozanzara.it/cdn/shop/products/jurassicpark_1200x1200.png?v=1658481575', 1043000000, 1, 4),
(2, 'Schindler''s List', 1993, 195, 'La storia vera di un imprenditore che salvò centinaia di ebrei.', 'https://mr.comingsoon.it/imgdb/locandine/big/35577.jpg', 322000000, 1, 3),
(3, 'Ready Player One', 2018, 140, 'Un ragazzo cerca un tesoro nascosto in un mondo virtuale.', 'https://static.posters.cz/image/750/57742.jpg', 582000000, 1, 1),
(4, 'Inception', 2010, 148, 'Un ladro entra nei sogni delle persone per rubare segreti.', 'https://i.ebayimg.com/images/g/rJUAAOSw~e5ZW6ol/s-l1200.jpg', 836000000, 2, 1),
(5, 'Interstellar', 2014, 169, 'Un gruppo di astronauti cerca nuovi mondi abitabili.', 'https://pad.mymovies.it/filmclub/2014/01/001/locandina.jpg', 701000000, 2, 1),
(6, 'The Dark Knight', 2008, 152, 'Batman affronta il criminale Joker a Gotham City.', 'https://m.media-amazon.com/images/I/5151N2hUPiL.jpg', 1005000000, 2, 2),
(7, 'Pulp Fiction', 1994, 154, 'Storie intrecciate del mondo criminale di Los Angeles.', 'https://pad.mymovies.it/filmclub/2006/08/102/locandinapg2.jpg', 213000000, 3, 5),
(8, 'Kill Bill Vol.1', 2003, 111, 'Una sposa tradita cerca vendetta contro i suoi ex complici.', 'https://m.media-amazon.com/images/I/71UWqAOKHaL.jpg', 180000000, 3, 2),
(9, 'Django Unchained', 2012, 165, 'Uno schiavo liberato diventa cacciatore di taglie.', 'https://m.media-amazon.com/images/I/81sfuF1VbaL.jpg', 426000000, 3, 4),
(10, 'Titanic', 1997, 195, 'Una storia d’amore durante il tragico viaggio del Titanic.', 'https://m.media-amazon.com/images/I/71FIao4X5PL._AC_UF894,1000_QL80_.jpg', 2200000000, 4, 3),
(11, 'Avatar', 2009, 162, 'Un soldato esplora il pianeta Pandora e si unisce ai nativi.', 'https://pad.mymovies.it/filmclub/2010/10/203/locandinapg1.jpg', 2923000000, 4, 1),
(12, 'Terminator 2', 1991, 137, 'Un cyborg protegge un ragazzo destinato a salvare l’umanità.', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWKj7YomS4MFt26snBrXKHA-LqxOC8caea1A&s', 520000000, 4, 2),
(13, 'Alien', 1979, 117, 'L’equipaggio di una nave spaziale incontra una creatura mortale.', 'https://images.photowall.com/products/59754/alien.jpg?h=699&q=85', 106000000, 5, 5),
(14, 'Gladiator', 2000, 155, 'Un generale romano diventa gladiatore per vendicare la sua famiglia.', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMyz9IHyVqmLuINkKTfzeDS8n2BfqwPz3gsQ&s', 460000000, 5, 4),
(15, 'The Martian', 2015, 144, 'Un astronauta sopravvive da solo sul pianeta Marte.', 'https://pad.mymovies.it/filmclub/2015/06/033/locandina.jpg', 630000000, 5, 1);

SET IDENTITY_INSERT film OFF;
GO

CREATE TABLE users (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(100) NOT NULL UNIQUE,
    pwd VARCHAR(255) NOT NULL,
    residenza VARCHAR(100),
    regione VARCHAR(100)
);
GO

SET IDENTITY_INSERT users ON;

INSERT INTO users (id_user, email, pwd, residenza, regione) VALUES
(1, 'mario.rossi@email.com', 'password123', 'Torino', 'Piemonte'),
(2, 'luca.bianchi@email.com', 'qwerty', 'Milano', 'Lombardia'),
(3, 'anna.verdi@email.com', 'ciao123', 'Roma', 'Lazio'),
(4, 'giulia.neri@email.com', 'test456', 'Bologna', 'Emilia-Romagna'),
(5, 'paolo.gialli@email.com', 'admin', 'Napoli', 'Campania');

SET IDENTITY_INSERT users OFF;
GO