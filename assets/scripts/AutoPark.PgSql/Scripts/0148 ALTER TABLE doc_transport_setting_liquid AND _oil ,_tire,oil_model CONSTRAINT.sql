ALTER TABLE doc_transport_setting_liquid 
ALTER COLUMN liquid_type_id DROP DEFAULT;

ALTER TABLE doc_transport_setting_liquid 
ADD CONSTRAINT fk_liquid_type_id 
	FOREIGN KEY (liquid_type_id)
		REFERENCES info_liquid_type (id);



ALTER TABLE doc_transport_setting_oil 
ALTER COLUMN oil_model_id DROP DEFAULT;

ALTER TABLE doc_transport_setting_oil 
ADD CONSTRAINT fk_oil_model_id 
	FOREIGN KEY (oil_model_id)
		REFERENCES info_oil_model (id);


ALTER TABLE doc_transport_setting_tire 
ALTER COLUMN tire_size_id DROP DEFAULT;

ALTER TABLE doc_transport_setting_tire 
ADD CONSTRAINT fk_tire_size_id
	FOREIGN KEY (tire_size_id)
		REFERENCES info_tire_size (id);


ALTER TABLE info_oil_model 
ALTER COLUMN oil_type_id DROP DEFAULT;

ALTER TABLE info_oil_model 
ADD CONSTRAINT fk_oil_type_id_info_oil_model 
	FOREIGN KEY (oil_type_id)
		REFERENCES info_oil_type (id);