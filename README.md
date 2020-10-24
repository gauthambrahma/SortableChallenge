# SortableChallenge

To run the docker container please use the commands below.

```
$ docker build -t challenge .
$ docker run -i -v /<absolute-path-to-sortable-project>/config.json:/auction/config.json challenge < /<absolute-path-to-sortable-project>/input.json
```

Custom inputs folder have some cases for validations. Below is a brief description.

* **MultipleCompanies**
	
	This input tests if the program works as intended with multiple sites as input.	 
	
* **EmptyBids**

	This input tests where an empty list of bid should be returned if there are no valid bids

* **BidderNotRecognized**
	
	This input test if a bidder is not present in the list of bidders in config. That bidder's bids are excluded.
	
* **BidderNotPermitted**
	
	When a bidder is not permmited on a site. Which means they are not included in "bidders" array for that site in the config. Their bids are excluded.
	
	
* **AdUnitNotInvolved**	
	
	When a bidder is bidding for a unit which is not included in units array in input for that site. Their bids are exluded.
	
The custom cases can be run using below commands

```
# Build 
$ docker build -t challenge .

# Multiple Companies
$ docker run -i -v /<absolute-path-to-sortable-project>/CustomInputs/MultipleCompanies/config.json:/auction/config.json challenge < /<absolute-path-to-sortable-project>/CustomInputs/MultipleCompanies/input.json

# Empty Bids
$ docker run -i -v /<absolute-path-to-sortable-project>/CustomInputs/EmptyBids/config.json:/auction/config.json challenge < /<absolute-path-to-sortable-project>/CustomInputs/EmptyBids/input.json

# Bidder Not Recognized
$ docker run -i -v /<absolute-path-to-sortable-project>/CustomInputs/BidderNotRecognized/config.json:/auction/config.json challenge < /<absolute-path-to-sortable-project>/CustomInputs/BidderNotRecognized/input.json

# Bidder Not Permitted
$ docker run -i -v /<absolute-path-to-sortable-project>/CustomInputs/BidderNotPermitted/config.json:/auction/config.json challenge < /<absolute-path-to-sortable-project>/CustomInputs/BidderNotPermitted/input.json

# Ad Unit Not Involved
$ docker run -i -v /<absolute-path-to-sortable-project>/CustomInputs/AdUnitNotInvolved/config.json:/auction/config.json challenge < /<absolute-path-to-sortable-project>/CustomInputs/AdUnitNotInvolved/input.json

```
	

#### Notes:

1. borrowed gitignore file from --> https://github.com/github/gitignore/blob/master/VisualStudio.gitignore 
2. Wonder what happens when two bidders bid for the same unit on a site for same price.(..and have same adjustment factor too). 🤔 Tie-breaking stratergies?