-- boot feature to set data
insert into user(id,username,email,password) values (1,'admin','admin@gmail.com','admin');
insert into user(id,username,email,password) values (2,'user1','abcdef@gmail.com','abcdef');
insert into user(id,username,email,password) values (3,'user3','asdfg@gmail.com','asdfg');

-- Sec Question Definitions to use
insert into secqa (user_id, question,answer) values (1, 'What is your favourite city?','Irving');
insert into secqa (user_id, question,answer) values (1, 'What is your first pet name?','Dog');
insert into secqa (user_id, question,answer) values (2, 'What is your favourite city?','Dallas');
insert into secqa (user_id, question,answer) values (2, 'What is your first pet name?','Cat');
insert into secqa (user_id, question,answer) values (3, 'What is your favourite city?','Celina');
insert into secqa (user_id, question,answer) values (3, 'What is your first pet name?','Snake');

