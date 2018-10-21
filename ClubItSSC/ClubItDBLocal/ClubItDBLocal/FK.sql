ALTER TABLE user
	ADD CONSTRAINT fk_user_type 
		FOREIGN KEY (user_type) REFERENCES user_type(user_type_id);

ALTER TABLE club_memeber
	ADD CONSTRAINT fk_club_id 
		FOREIGN KEY (club_id) REFERENCES club(club_id);

ALTER TABLE club_memeber
	ADD CONSTRAINT fk_cm_user_id 
		FOREIGN KEY (user_id) REFERENCES user(user_id);
		
