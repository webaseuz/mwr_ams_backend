# WebERP Backend Project Structure

This document outlines the organization and structure of the WebERP backend system.

## Overview

The WebERP backend is a microservices-based system built primarily with .NET technologies. The project follows a modular architecture with clear separation of concerns.

## Root Directory Structure

- `assets/` - Static assets and resources
- `build/` - Build configurations and output
- `devops/` - DevOps related configurations and scripts
- `docs/` - Project documentation
- `libs/` - Shared libraries and SDKs
- `packages/` - NuGet packages and dependencies
- `prototypes/` - Prototype implementations
- `scripts/` - Utility scripts for development and maintenance
- `services/` - Core microservices

## Microservices

The `services/` directory contains the individual microservices:

- `adm-service/` - Administration service
- `hrm-service/` - Human Resource Management service
- `web-bff/` - Backend-For-Frontend service for web clients

Each service follows a standard structure:
- `.sln` - Solution file
- `src/` - Source code
  - Service implementation
  - Service-specific libraries
- `test/` - Unit and integration tests

## Shared Libraries

The `libs/` directory contains shared code used across multiple services:

- `dotnet/` - .NET shared libraries
  - `core/` - Core functionality and utilities
  - `core-sdk/` - SDK components for integration
  - `core-service/` - Base service components

## Build System

The project uses a centralized build system with:
- `Directory.Build.props` - Common MSBuild properties
- `Directory.Packages.props` - Centralized package version management
- `Nuget.Config` - NuGet configuration

## Development Guidelines

When working with this codebase:

1. Each service should be independently deployable
2. Shared code belongs in the appropriate library under `libs/`
3. Service-specific code stays within the service's directory
4. Follow the established patterns for each service type

## Configuration

Configuration follows a layered approach:
- Base configurations in shared libraries
- Service-specific overrides within each service
- Environment-specific configurations managed through environment variables or config files
