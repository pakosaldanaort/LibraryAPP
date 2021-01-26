export interface IBook {
    bookId: number,
    title: string,
    author: string,
    isbn: string,
    CheckOutDate: Date,
    overDueDate : Date,
    userId: number,
    user: any,
}