const EMAIL_REGEX = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
const PASSWORD_MIN_LENGTH = 6;
const NAME_MIN_LENGTH = 3;

export const FieldRules = {
  EMAIL_REGEX,
  PASSWORD_MIN_LENGTH,
  NAME_MIN_LENGTH,
};
