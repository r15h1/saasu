--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.2
-- Dumped by pg_dump version 9.6.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE saas;
--
-- Name: saas; Type: DATABASE; Schema: -; Owner: -
--

CREATE DATABASE saas WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_Canada.1252' LC_CTYPE = 'English_Canada.1252';


\connect saas

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: tenant_settings; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE tenant_settings (
    tenant_id bigint NOT NULL,
    key character varying(20) NOT NULL,
    value character varying(1000) NOT NULL
);


--
-- Name: tenants; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE tenants (
    tenant_id bigint NOT NULL,
    name character varying(250) NOT NULL,
    email character varying(256) NOT NULL,
    active boolean DEFAULT true NOT NULL,
    ts_cr timestamp without time zone DEFAULT now() NOT NULL,
    ts_lmod timestamp without time zone DEFAULT now() NOT NULL,
    user_id bigint NOT NULL
);


--
-- Name: tenants_tenant_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE tenants_tenant_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: tenants_tenant_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE tenants_tenant_id_seq OWNED BY tenants.tenant_id;


--
-- Name: themes; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE themes (
    theme_id integer NOT NULL,
    name character varying(20) NOT NULL,
    snapshot_url character varying(200)
);


--
-- Name: themes_theme_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE themes_theme_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: themes_theme_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE themes_theme_id_seq OWNED BY themes.theme_id;


--
-- Name: tenants tenant_id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY tenants ALTER COLUMN tenant_id SET DEFAULT nextval('tenants_tenant_id_seq'::regclass);


--
-- Name: themes theme_id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY themes ALTER COLUMN theme_id SET DEFAULT nextval('themes_theme_id_seq'::regclass);


--
-- Data for Name: tenant_settings; Type: TABLE DATA; Schema: public; Owner: -
--

COPY tenant_settings (tenant_id, key, value) FROM stdin;
1	host	localhost:56816
2	host	localhost:5000
3	host	localhost:8000
1	theme	OnePage
2	theme	Flexor
3	theme	Moderna
\.


--
-- Data for Name: tenants; Type: TABLE DATA; Schema: public; Owner: -
--

COPY tenants (tenant_id, name, email, active, ts_cr, ts_lmod, user_id) FROM stdin;
1	Jane McLaren	jane@mclaren.com	t	2017-06-06 12:39:51.943376	2017-06-06 12:39:51.943376	1
2	Rocky Balboa	rocky@gmail.com	t	2017-06-06 12:40:16.944876	2017-06-06 12:40:16.944876	1
3	Alice Schmitz	alicia@mail.com	t	2017-06-06 12:40:58.812063	2017-06-06 12:40:58.812063	1
\.


--
-- Name: tenants_tenant_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('tenants_tenant_id_seq', 3, true);


--
-- Data for Name: themes; Type: TABLE DATA; Schema: public; Owner: -
--

COPY themes (theme_id, name, snapshot_url) FROM stdin;
1	Amoeba	\N
2	Baker	\N
3	Default	\N
4	eNno	\N
5	Flexor	\N
6	Hidayah	\N
7	Moderna	\N
8	OnePage	\N
9	Siimple	\N
\.


--
-- Name: themes_theme_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('themes_theme_id_seq', 9, true);


--
-- Name: tenants tenants_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY tenants
    ADD CONSTRAINT tenants_pkey PRIMARY KEY (tenant_id);


--
-- Name: themes themes_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY themes
    ADD CONSTRAINT themes_pkey PRIMARY KEY (theme_id);


--
-- Name: tenant_settings unique_tenant_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY tenant_settings
    ADD CONSTRAINT unique_tenant_key UNIQUE (tenant_id, key);


--
-- Name: tenant_settings tenant_settings_tenant_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY tenant_settings
    ADD CONSTRAINT tenant_settings_tenant_id_fkey FOREIGN KEY (tenant_id) REFERENCES tenants(tenant_id);


--
-- PostgreSQL database dump complete
--

