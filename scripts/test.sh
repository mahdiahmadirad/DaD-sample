#!/usr/bin/env bash
set -euo pipefail

dotnet test DaD.Sample.sln --configuration Release
