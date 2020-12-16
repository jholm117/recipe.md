[![Gitpod ready-to-code](https://img.shields.io/badge/Gitpod-ready--to--code-blue?logo=gitpod)](https://gitpod.io/#https://github.com/jholm117/recipe.md)
![test-snapshots](https://github.com/jholm117/recipe.md/workflows/test-snapshots/badge.svg)

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

## TODO

- response caching
- publish chrome extension
- api validation
- add more site selectors
- add recipe author to template
- add source url to template
- get deploy pipeline IaC
- run snapshot test job on schedule
- add react frontend
- serve recipes in html (MarkdownSharp)
