drop schema if exists library cascade;
create schema if not exists library;
CREATE TABLE library.books (
                       id integer GENERATED BY DEFAULT AS IDENTITY,
                       isbn character varying(13) NOT NULL,
                       title character varying(255) NOT NULL,
                       author character varying(255) NOT NULL,
                       publisher character varying(255),
                       publication_date date,
                       genre character varying(50),
                       description text,
                       page_count integer,
                       language character varying(50) DEFAULT ('English'::character varying),
                       format character varying(50),
                       price numeric(10,2),
                       stock_quantity integer DEFAULT 0,
                       is_available boolean DEFAULT TRUE,
                       created_at timestamp with time zone DEFAULT (CURRENT_TIMESTAMP),
                       updated_at timestamp with time zone DEFAULT (CURRENT_TIMESTAMP),
                       CONSTRAINT books_pkey PRIMARY KEY (id)
);


CREATE UNIQUE INDEX books_isbn_key ON library.books (isbn);


CREATE INDEX idx_books_author ON library.books (author);


CREATE INDEX idx_books_isbn ON library.books (isbn);


CREATE INDEX idx_books_title ON library.books (title);

