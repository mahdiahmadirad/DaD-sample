#!/usr/bin/env bash
set -euo pipefail

dotnet restore DaD.Sample.sln
dotnet build DaD.Sample.sln --no-restore --configuration Release
