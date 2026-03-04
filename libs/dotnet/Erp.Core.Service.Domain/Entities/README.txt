    [Column("code")]
    public string Code { get; set; }

    [Column("order_code")]
    public string OrderCode { get; set; }

    [Column("short_name")]
    public string ShortName { get; set; }

    [Column("full_name")]
    public string FullName { get; set; }

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("translate_text")]
    public string TranslateText { get; set; }

    [Column("column_name")]
    public string ColumnName { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("last_modified_at")]
    public DateTime? LastModifiedAt { get; set; }

    [Column("created_by")]
    public long? CreatedBy { get; set; }

    [Column("last_modified_by")]
    public long? LastModifiedBy { get; set; }

    // Navigation properties
    public Language Language { get; set; } = null!;
    public Gender Owner { get; set; } = null!;


    [Column("state_id")]
    public int StateId { get; set; }

    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("org_id")]
    publicint OrganizationId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }