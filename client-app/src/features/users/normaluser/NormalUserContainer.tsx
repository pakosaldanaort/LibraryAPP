import React, { useEffect, useState } from 'react'
import { Button, Container, Grid } from 'semantic-ui-react'
import agent from '../../../app/api/agent';
import { IBook } from '../../../app/models/book';
import { BookList } from '../librarian/forms/BookList';

interface IProps {
    userId: number
}

export const NormalUserContainer: React.FC<IProps> = ({userId}) => {
    const [showUserView, setUserView] = useState(0);
    const [books, setBooks] = useState<IBook[]>([]);
    const [noCheckedOutBooks, setNoCheckedOutBooks] = useState<IBook[]>([]);
    
    useEffect(() => {
        agent.User.listBooks(userId)
            .then((response) => {
                setBooks(response)
            });
        agent.User.getNoCheckedOutBooks()
            .then((response) => {
                setNoCheckedOutBooks(response)
            });
      }, [userId, noCheckedOutBooks]);

      var actions = (action: number) => {
        switch (action) {
            case 1:
                return  <BookList books={noCheckedOutBooks} isLibrarian={false} showOverDueDate={false} checkOutBooks={true} showReturnBook={false} userId={userId}/>
            case 2 :
                return <BookList books={books} isLibrarian={false} showOverDueDate={true} checkOutBooks={false} showReturnBook={true} userId={userId}/>
            case 3:
                return <BookList books={books} isLibrarian={false} showOverDueDate={true} checkOutBooks={false} showReturnBook={false} userId={userId}/>
            default:
                break;
        }
    }

    return (
        <Container style={{marginTop: '3em'}}>
            <Grid>
                <Grid.Column width={16}>
                    <Button color='teal' onClick={() => setUserView(1)}>Check Out Book</Button>
                    <Button color='blue' onClick={() => setUserView(2)}>Return Checked Out Book</Button>
                    <Button color='violet' onClick={() => setUserView(3)}>Current Checked Out Books</Button>
                </Grid.Column>
            </Grid>
            <Container>
                {actions(showUserView)}
            </Container>
        </Container>
    )
}