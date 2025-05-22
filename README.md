# Nice Part Usage

## Considerations

- Api Gateway and external Identity Provider
-- But need GenerateToken use case for example to work

- Clean Architecture

- REST interface with RFC7807 errors

- Minimal API due to speed

- REPR Pattern

- Mediator
-- Provides separation
-- Provides processing pipeline
--- Authorization
--- Validation
--- OTel recording of exceptions
--- ...

- Exceptions instead of Result Pattern: Readability + Waiting for DU in C#.

- Azure Blob Storage (could be AWS S3 or similar)

- No unit tests... ;-)
-- But a few architecture tests as these as important


## TODO

Consider attributes members as "proper" lists?

Make sure that Tokens/Security types are correctly located within
either Domain or Infrastructure (not correct now!!)

TokenId vs. IdentityId

Create Otel MediatR pipeline

Generate token examples

... 
