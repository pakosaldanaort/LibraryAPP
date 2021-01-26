import React, { useState } from 'react'
import { Button, Form, Segment } from 'semantic-ui-react'
import agent from '../../../../app/api/agent';
import { IBook } from '../../../../app/models/book';


export const AddBookForm = () => {
    const newBook = {
        title: '',
        author: '',
        isbn: ''
    };

    const [book, setBook] = useState(newBook);

    const handleInputChange = (event: any) => {
        const { name, value } = event.target;
        setBook({...book, [name] : value});
    }

    const submitBook = (book: any) => {
        agent.Librarian.addBook(book).then((response) =>{
            alert(response);
            setBook(newBook);
        });
    }

    return (
        <Segment clearing style={{marginTop: '0.5em'}}>
            <Form>
                <Form.Input placeholder='Book Title' name='title' onChange={handleInputChange} value={book.title}/>
                <Form.Input placeholder='Book Author' name='author' onChange={handleInputChange} value={book.author}/>
                <Form.Input placeholder='ISBN' name='isbn' onChange={handleInputChange} value={book.isbn}/>
                <Button floated='right' positive type='submit' content='Submit' onClick={() => submitBook(book)}></Button>
                <Button floated='right'  type='button' content='Cancel'></Button>
            </Form>
        </Segment>
    )
}