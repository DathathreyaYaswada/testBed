CREATE TABLE IF NOT EXISTS user (
     id  INTEGER  AUTO_INCREMENT PRIMARY KEY,
     username VARCHAR(50) NOT NULL,
     email VARCHAR(50) NOT NULL,
     password VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS secqa (
    id INTEGER AUTO_INCREMENT PRIMARY KEY,
    user_id INTEGER,
    question VARCHAR(100) NOT NULL,
    answer VARCHAR(100) NOT NULL,
    FOREIGN KEY (user_id) references user(id)
);
