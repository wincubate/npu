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

## TODO

Create Otel MediatR pipeline

Generate token examples

... 
