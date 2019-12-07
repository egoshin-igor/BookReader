import { UserBookStatus } from '../../constants/userBookStatus';

export interface BookDto{
    id: number;
    name: string;
    jenreName: string;
    imagePath: string;
    author: string;
    status: UserBookStatus;
}