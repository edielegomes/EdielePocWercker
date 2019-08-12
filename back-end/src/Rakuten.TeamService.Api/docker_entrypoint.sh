#!/bin/bash
cd /pipeline/source/app/publish
dotnet Rakuten.TeamService.Api.dll --server.urls=http://0.0.0.0:${PORT-"8080"}