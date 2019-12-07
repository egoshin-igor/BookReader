import { UserBookStatus } from '../../constants/userBookStatus';

export interface BookDto{
    name: string;
    jenreName: string;
    imagePath: string;
    author: string;
    status: UserBookStatus;
}