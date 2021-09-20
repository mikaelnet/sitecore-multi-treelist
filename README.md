# sitecore-multi-treelist
Sitecore TreeList/TreeListEx with support for multiple roots and better Source query options.

## Description
This module basically adds two new template field types:

* Treelist with Multiple Roots
* TreelistEx with Multiple Roots

All in all, they should work identical to Sitecore's built-in Treelist and TreelistEx field types,
but these supports multiple datasources in the Source string of the field.

The built-in Treelist(Ex) Source strings come in two main flavours:

* Simple: `<query or ID or path>`
* Parameterized: `DataSource=<ID or path>&ExcludeTemplatesForDisplay=...&...`

This multi-root field support both versions as well, but with pipe-separated datasources:

* `<ds1>|<ds2>|...`
* `DataSource=<ds1>|<ds2>|...&ExcludeTemplatesForDisplay=...&...`

In addition, it also support four main types of datasources:

* `<ID>`
* `<full path>` (/sitecore/...)
* `query:` (note that for obvious reasons having a | character is not supported within a query)
* `code:` (must implement `Sitecore.Buckets.FieldTypes.IDataSource`)

### ContentSearch/Solr
Since this is a new field type, it also needs to be recognized by Sitecore ContentSearch so
that it'll be indexed properly in Solr. 

### Note
The code is extracted from a larger project, so it's somewhat untested in a clean solution.

### Credits
Kudos to [Jonas Hamnered](https://twitter.com/jomiham) who made a lot of work making this module possible.
