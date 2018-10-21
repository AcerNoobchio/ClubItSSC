CREATE TABLE user_type
(
	user_type_id VARCHAR(5) NOT NULL,
	user_type_description VARCHAR(50) NOT NULL,

	CONSTRAINT pk_user_type_id PRIMARY KEY (user_type_id)	
)
