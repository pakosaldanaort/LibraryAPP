import React, { useEffect, useState } from 'react'
import { Button, Container, Grid } from 'semantic-ui-react'
import agent from '../../../app/api/agent'
import { IBook } from '../../../app/models/book'
import { AddBookForm } from './forms/AddBookForm'
import { BookList } from './forms/BookList'

export const LibrarianContainer = () => {
    const [showUserView, setUserView] = useState(0);
    const [books, setBooks] = useState<IBook[]>([]);
    const [overDueBooks, setOverDueBooks] = useState<IBook[]>([]);
  
  useEffect(() => {
      agent.Librarian.getAllBooks()
        .then((response) => {
            setBooks(response)
        });
    agent.Librarian.getOverDueBooks()
        .then((response) => {
            setOverDueBooks(response)
        });
  }, [books]);

  var actions = (action: number) => {
      switch (action) {
          case 1:
              return  <AddBookForm/>
          case 2 :
              return <BookList books={books} isLibrarian={true} showOverDueDate={false} checkOutBooks={false} showReturnBook={false} userId={1}/>
          case 3:
              return <BookList books={overDueBooks} isLibrarian={false} showOverDueDate={true} checkOutBooks={false} showReturnBook={false} userId={1}/>
          default:
              break;
      }
  }
  
    return (
        <Container style={{marginTop: '3em'}}>
            <Grid>
                <Grid.Column width={10}>
                    <Button color='teal' onClick={() => setUserView(1)}>Add Book</Button>
                    <Button color='blue' onClick={() => setUserView(2)}>Remove Book</Button>
                    <Button color='violet' onClick={() => setUserView(3)}>OverDue Books</Button>
                </Grid.Column>
            </Grid>
            <Container>
                {actions(showUserView)}
            </Container>
        </Container>
    )
}