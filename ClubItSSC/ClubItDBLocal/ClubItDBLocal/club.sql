CREATE TABLE [dbo].club
(
	club_id VARCHAR(5) NOT NULL,
	club_name VARCHAR(50) NOT NULL,
	club_status VARCHAR(1) NOT NULL,

	CONSTRAINT pk_club_id PRIMARY KEY (club_id)
)
