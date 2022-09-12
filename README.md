# C-Socket-Text-Game
Use the socket class library of C # to write, combine with MySQL database to store, support creating rooms, adding rooms, deleting rooms, and real-time conversations
You can set the connstring member variable in the mysqlconn class in "solution / coon. CS" to a modify the location of your database.

You can create the required table through the following SQL statements:\n
Table1:
Create Table: CREATE TABLE `room` (
  `rnum` int NOT NULL,
  `model` int NOT NULL,
  PRIMARY KEY (`rnum`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

Table2:
Create Table: CREATE TABLE `user` (
  `id` varchar(45) NOT NULL,
  `password` varchar(45) DEFAULT NULL,
  `point` varchar(45) DEFAULT NULL,
  `usercol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `usercol_UNIQUE` (`usercol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
