ALTER TABLE doc_transport_setting_liquid 
ADD liquid_type_id INT NOT NULL DEFAULT 1;

ALTER TABLE doc_transport_setting_oil 
ADD oil_model_id INT NOT NULL DEFAULT 1;

ALTER TABLE doc_transport_setting_tire
ADD tire_size_id INT NOT NULL DEFAULT 1;
