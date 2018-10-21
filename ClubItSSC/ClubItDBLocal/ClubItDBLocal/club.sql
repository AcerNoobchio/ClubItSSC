CREATE TABLE [dbo].[Table1]
(
	club_id VARCHAR2(5) NOT NULL,
	club_name VARCHAR2(50) NOT NULL,
	club_status VARCHAR2(1) NOT NULL,

	CONSTRAINT pk_club_id PRIMARY KEY (club_id)
)
