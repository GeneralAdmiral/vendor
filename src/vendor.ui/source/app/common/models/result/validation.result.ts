import { Validation } from '../validation.model';

export class ValidationResult {
    isValid: boolean;
    validations: Validation[] = [];
}