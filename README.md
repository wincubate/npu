# Nice Part Usage

## Considerations

- Api Gateway and external Identity Provider
-- But need GenerateToken use case for example to work :-)

- Clean Architecture

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

## TODO

[Endpoint] attribute

Map ValidationException to Problem



... 
