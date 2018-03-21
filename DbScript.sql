
CREATE DATABASE `livraria2`;

CREATE TABLE `livraria2`.`livros` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `autor` varchar(45) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
