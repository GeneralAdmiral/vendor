import { Product } from '../product.model';
import { Language } from '../language.model';
import { UserProduct } from './user.product.model';
import { User } from '../user.model';

export class ProductLanguage {
    parentId: number;
    languageId: number;
    name: string;
    description: string;
    // update: string;
    userUpdateId: number;
    parent: Product;
    language: Language;
    userUpdate: User;
}