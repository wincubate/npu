# Nice Part Usage

## Considerations

- Api Gateway and external Identity Provider
-- But need GenerateToken use case for example to work

- Clean Architecture

- REST interface with RFC7807 errors

- .NET 9 with Minimal API due to speed

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

- Parts List should be imported / synchronized from external source / Cached
-- Currently list is hardcoded
-- For simplicity: Only a single part per submission. If there was a bit more time: one-to-many

- No unit tests... ;-)
-- But a few architecture tests as these are also important


## TODO

Run architecture tests: Mappers should be internal

Clean up Program.cs

Remember to set token expiration back to 60 minutes. :-)

Image as separate identity? (same aggregate as Submission)
GuidGenerator for Blob and other Ids?

Remove hardcoded HOST strings: 7044

Clean up seeding part / connection string

Generate token examples

EF Core missing Foreign Keys?

... 
