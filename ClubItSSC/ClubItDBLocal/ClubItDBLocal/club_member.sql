CREATE TABLE [dbo].[club_member]
(
	club_id VARCHAR(5) NOT NULL,
	user_id VARCHAR(5) NOT NULL,
	club_memeber_status VARCHAR(1) NOT NULL,
	club_admin VARCHAR(1),

	CONSTRAINT pk_club_member PRIMARY KEY (club_id, user_id), 
    CONSTRAINT [fk_club_id] FOREIGN KEY ([club_id]) REFERENCES [dbo].[club]([club_id]), 
    CONSTRAINT [fk_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[user]([user_id])
)
