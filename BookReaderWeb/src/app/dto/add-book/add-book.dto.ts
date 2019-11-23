export interface AddBookDto {
    name: string;
    author: string;
    genreId: number;
    bookImage: File;
    bookFile: File;
}