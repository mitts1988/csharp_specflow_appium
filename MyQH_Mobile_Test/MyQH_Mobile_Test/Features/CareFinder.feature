Feature: Care Finder

Background: 
Given user has logged in
And is on the Care Finder page

@carefinder
Scenario Outline: Search for a provider by name
When user searches Care Finder for a <searchType> with <searchTerm> near <zip>
Then results displayed match the API call results

Examples: 
| searchType      | searchTerm           | zip     |
| facilityByName  | hospital             | default |
| facilityByName  | Wexner               | 43016   |
| facilityByName  | Emergency            | 32244   |
| facilityByType  | Allergy & Immunology | default |
| facilityByType  | random               | 20500   |
| procedureByName | cardiac stent        | default |
| procedureByName | knee                 | 43201   |

