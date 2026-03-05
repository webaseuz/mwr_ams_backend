CREATE UNIQUE INDEX idx_hl_transport_state1_vin_number
    ON hl_transport (vin_number)
    WHERE state_id = 1;


CREATE UNIQUE INDEX idx_hl_transport_state1_state_number
    ON hl_transport (state_number)
    WHERE state_id = 1;
