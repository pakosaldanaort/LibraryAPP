import axios, { AxiosResponse } from 'axios'
import { IBook } from '../models/book';
import { IUser } from '../models/user';

axios.defaults.baseURL = 'http://localhost:5000/';

const responseBody = (response : AxiosResponse) => response.data;

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url:string) => axios.put(url).then(responseBody),
    del: (url:string) => axios.delete(url).then(responseBody)
}

const Librarian = {
    getOverDueBooks: (): Promise<IBook[]> => requests.get('Librarian/OverDueBooks'),
    getAllBooks: (): Promise<IBook[]> => requests.get('Librarian/GetAllBooks'),
    addBook: (book: any) => requests.post('Librarian/AddBook', book),
    deleteBook:(bookId: number) => requests.del(`Librarian/DeleteBook/${bookId}`)
}

const User = {
    listBooks: (userId: number): Promise<IBook[]> => requests.get(`User/ListBooks/${userId}`),
    getUsers: (): Promise<IUser[]> => requests.get('User/GetUsers'),
    getNoCheckedOutBooks: (): Promise<IBook[]> => requests.get('User/GetNoCheckedOutBooks'),
    checkOutBook: (userId: number, bookId: number) => requests.put(`User/CheckOutBook/${userId}/${bookId}`),
    returnBook: (bookId: number) => requests.put(`User/ReturnBook/${bookId}`)
}

export default {
    Librarian,
    User
}