CREATE TABLE [dbo].[user]
(
	user_id VARCHAR(5) NOT NULL,
	user_f_name VARCHAR(50) NOT NULL,
	user_l_name VARCHAR(50) NOT NULL,
	user_email VARCHAR(50) NOT NULL,
	user_password VARCHAR(50) NOT NULL,
	user_type VARCHAR(50) NOT NULL,
	CONSTRAINT pk_user_id PRIMARY KEY (user_id), 
    CONSTRAINT [fk_user_type] FOREIGN KEY ([user_type]) REFERENCES [dbo].[user_type]([user_type_id]) 
)
