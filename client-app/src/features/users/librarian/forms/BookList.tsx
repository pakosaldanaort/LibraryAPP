import React from 'react'
import { Button, Card, Container, Message } from 'semantic-ui-react'
import agent from '../../../../app/api/agent'
import { IBook } from '../../../../app/models/book'

interface IProps {
    books: IBook[],
    isLibrarian: boolean,
    showOverDueDate: boolean,
    checkOutBooks: boolean,
    showReturnBook: boolean,
    userId: number
}

export const BookList: React.FC<IProps> = ({books, isLibrarian, showOverDueDate, checkOutBooks, showReturnBook, userId}) => {
    const deleteBook = (bookId: number) => {
        agent.Librarian.deleteBook(bookId).then((response) =>{
            books = books.filter((book) => book.bookId !== bookId);
            alert(response);
        });
    }

    const checkOutBook = (userId: number, bookId:number) => {
        agent.User.checkOutBook(userId, bookId).then((response) => {
            books = books.filter((book) => book.bookId !== bookId);
            alert(response);
        })
    }

    const returnBook = (bookId: number) => {
        agent.User.returnBook(bookId).then((response) => {
            alert(response);
        });
    }
    return (
        <Container>
            {
                books.length == 0 && <Message error header='No Books Found' style={{marginTop: '3em'}}/>
            }
            <Card.Group>
            {
                books.map((book) => (
                    <Card key={book.bookId}>
                        <Card.Content>
                            <Card.Header>{book.title}</Card.Header>
                            <Card.Meta>{book.author}</Card.Meta>
                            <Card.Description>
                                ISBN: {book.isbn}
                                {
                                    showOverDueDate ? (<p>{'Overdue Date: ' + new Date(book.overDueDate).toDateString()}</p>) : ''
                                }
                            </Card.Description>
                        </Card.Content>
                        <Card.Content extra>
                            <div className='ui two buttons'>
                                {
                                    !showOverDueDate && isLibrarian ? 
                                        (<Button basic color='red' onClick={() => deleteBook(book.bookId)}> Delete </Button>) : ''
                                }
                                {
                                    !isLibrarian && checkOutBooks ?
                                        (<Button basic color='blue' onClick={() => checkOutBook(userId, book.bookId)}> Check-Out Book </Button>) : ''
                                }
                                {
                                    !isLibrarian && showReturnBook ?
                                        (<Button basic color='green' onClick={() => returnBook(book.bookId)}> Return Book </Button>) : ''
                                }
                            </div>
                        </Card.Content>
                    </Card>
                ))
            }
            </Card.Group>
        </Container>
        
    )
}