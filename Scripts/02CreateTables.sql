CREATE TABLE tenants (
    tenantid serial primary key not null,
    name varchar(100) not null,
    email varchar(320) not null,
    datecreated timestamp with time zone not null,
    isactive boolean not null
);

CREATE TABLE tenantsettings (
	tenantid int not null,
    key varchar(20) not null,
    value text not null
);

ALTER TABLE tenantsettings ADD CONSTRAINT "fk_tenants_tenantsettings_tenantid" FOREIGN KEY (tenantid) REFERENCES tenants (tenantid);
CREATE UNIQUE INDEX "idx_u_tenantsettings_tenantid_key" ON tenantsettings (tenantid, key);

