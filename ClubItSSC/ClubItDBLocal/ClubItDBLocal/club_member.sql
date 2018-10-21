CREATE TABLE [dbo].[Table2]
(
	club_id VARCHAR2(5) NOT NULL,
	user_id VARCHAR2(5) NOT NULL,
	club_memeber_status VARCHAR2(1) NOT NULL,
	club_admin VARCHAR2(1),

	CONSTRAINT pk_club_member PRIMARY KEY (club_id, user_id)
)
