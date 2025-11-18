USE AulaADO;

SELECT * FROM Pessoas;

SELECT * FROM Telefones;

delete from pessoas where id = 7;

select * from Pessoas p
JOIN Telefones t
ON p.id = t.pessoaId


insert into Telefones VALUES 
('11','123123','fixo',8)


insert into Telefones VALUES 
('16','321321','recado',1002)


insert into Telefones VALUES 
('17','432432','cell',1002)

insert into Pessoas VALUES
('Felipe Pestana', '123123','1990/04/09')
