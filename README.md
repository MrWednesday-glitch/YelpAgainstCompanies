# Yelp Against Companies
This is an webapp to judge how a company treated employees either in their employment or search for employment.

### Raison d être
> This app is based on a recurring joke in unemployment circles on how employees should be able to judge employers/companies on how the former is treated by the latter.
> By doing so employees would warn each other not to waste time with certain employers and or companies.

### Functionality
> The frontend would be like a forum where visitors could click on the name of a company
> which would open up a new page of the company with an itemized list of comments by user, including individual ratings.
> With every new comment and rating the average rating of the company is updated.
> To make a new company/comment and rate companies employees should be logged in.
> To see the ratings and companies users do not need to be logged in.

### Problems (and how I solved them)
* Problems with entity framework (migrations, relationships, seeding, etc.)
  => Solving issues with the Guid had me delete the established database and migrations and start anew. I also needed a minute to remember how to properly set up relations by using eager loading.
* Problems with a singular component in angular requiring miltiple endpoints of the api to retrieve the relevant data, because they are async data does not load properly into the html. 
  => For now I have one function to get the ratings inside the function to get the company, but it is an ugly solution, so maybe later make a new endpoint that actually retrieves the data in a single json to match the single angular component.
