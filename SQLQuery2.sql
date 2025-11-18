USE AulaADO;

SELECT * FROM Pessoas;

SELECT * FROM Telefones;

SELECT * FROM Enderecos;

delete from Enderecos where pessoaId = 1002;
delete from Telefones where pessoaId = 1002;
delete from Pessoas where Id = 1002;

select 
p.id, 
p.nome, 
p.cpf, 
p.dataNascimento, 
e.logradouro, 
e.numero, 
e.complemento,
e.bairro,
e.cidade,
e.estado,
e.cep,
t.ddd,
t.numero,
t.tipo,
t.pessoaId 
from Pessoas p
LEFT JOIN Enderecos e
ON e.pessoaId = p.id
LEFT JOIN Telefones t
ON p.id = t.pessoaId

insert into Telefones VALUES 
('11','123123','fixo',8)

insert into Telefones VALUES 
('16','321321','recado',1002)

insert into Telefones VALUES 
('17','432432','cell',1002)

insert into Pessoas VALUES
('Felipe Pestana', '123123','1990/04/09')
