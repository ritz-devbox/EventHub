# EventHub
A clean-architecture, cloud-ready event scheduling and registration API built with .NET 8, Postgres, Docker, and full CI/CD pipelines.

## Local setup
Ensure your environment matches CI so pull requests succeed:

1. Install the .NET 8 SDK (the repo pins 8.0.100 via `global.json`).
2. Restore packages:
   ```bash
   dotnet restore
   ```
3. Verify formatting (CI runs this step):
   ```bash
   dotnet format --verify-no-changes
   ```
4. Build in Release mode:
   ```bash
   dotnet build --configuration Release --no-restore
   ```
5. Run tests with coverage (mirrors CI):
   ```bash
   dotnet test --configuration Release --no-build --collect "XPlat Code Coverage"
   ```
6. Check vulnerable dependencies:
   ```bash
   dotnet list package --vulnerable
   ```

Running the above commands locally before opening a PR will align with the CI workflow and reduce failures.
