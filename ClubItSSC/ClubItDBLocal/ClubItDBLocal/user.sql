CREATE TABLE [dbo].[Table1]
(
	user_id VARCHAR2(5) NOT NULL,
	user_f_name VARCHAR2(50) NOT NULL,
	user_l_name VARCHAR2(4) NOT NULL,
	user_email VARCHAR2(50) NOT NULL,
	user_password VARCHAR2(50) NOT NULL,
	user_type VARCHAR2(5) NOT NULL,
	CONSTRAINT pk_user_id PRIMARY KEY (user_id)
)
