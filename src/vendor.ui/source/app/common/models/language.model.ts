import { Product } from './product.model';
import { ProductLanguage } from './many_to_many/product.language.model';
import { User } from './user.model';

export class Language {
    id: number;
    alias: string;
    isDefault: boolean;
    name: string;
    // update : string;
    userUpDateId: number;
    userUpdateId: number;
    userLanguage: User;
    productLanguages: ProductLanguage[];
    userUpdate: User;
}