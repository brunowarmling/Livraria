Feature: Book
	In order to maintain the book inventory
	As a user i want to create, update, delete, and select books so that 
	So that i will be able to maintain the book inventory

Scenario Outline: Insert a valid book
	 Given I have entered name <name> into the book page
       And I have also entered author <author> into book page
      When I press add
      Then the result should be success

      Examples:
      | name        | author        |
      | 'test'      | 'test'        |
      | 'test name' | 'test author' |
      | '123 test'  | '123 test'    |

Scenario Outline: Edit a book
	 Given I have entered id <id> into the book page
	   And I have entered name <name> into the book page
       And I have also entered author <author> into book page
      When I press Save
      Then the result should be success
          
      Examples:
      | id | name        | author      |
      | 1  | 'new test'  | 'new value' |
      | 1  | 'new name'  | 'new test'  |
      | 1  | 'new value' | '123'       |

Scenario Outline: Delete a book
	 Given I have entered id <id> into the book page
      When I press Delete
      Then the result should be success
          
      Examples:
      | id |
      | 1  |

Scenario Outline: Select books by code
	  Given I have entered id <id> into the book page
	  When I press Find
      Then the result should be success
          
      Examples:
      | id |
      | 1  |
	  | 2  |
	  | 3  |

Scenario Outline: Select books by name
	  Given I have entered name <name> into the book page
	  When I press Find
      Then the result should be success
          
      Examples:
      | name    |
      | 'test'	|
	  | 'te'    |
	  | 't'     |

Scenario Outline: Select books by author
	  Given I have entered author <author> into book page
	  When I press Find
      Then the result should be success
          
      Examples:
      | author  |
      | 'test'	|
	  | 'te'    |
	  | 't'     |
