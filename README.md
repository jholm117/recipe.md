[![Gitpod ready-to-code](https://img.shields.io/badge/Gitpod-ready--to--code-blue?logo=gitpod)](https://gitpod.io/#https://github.com/jholm117/recipe.md)

# recipe.md

- stdin = url to recipe
- stdout = markdown

## Supported Sites

- allrecipes.com
- cookieandkate.com
- thespruceeats.com

## Goals

- work for many popular sites
- run on mobile
- save past recipes
- substitutions
- tree instructions (multiple methods)
- pictures

## Issues

- module exports
- search state not in URL
- CORS

## Server

- node express
- one endpoint
  - request: url
  - response: recipe info
- graphql?
  - good to learn
  - take more time
  - unnecessary
- deploy to heroku
