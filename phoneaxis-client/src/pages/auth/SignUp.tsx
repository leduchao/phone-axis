import {
  TextField,
  Typography,
  Box,
  FormControlLabel,
  Checkbox,
  Button,
  Link,
  Container,
} from "@mui/material";
import { ROUTES } from "../../routes";
import { Controller, useForm } from "react-hook-form";
import { SignUpRequest } from "../../models/auth-model";
import { authApi } from "../../apis/auth-api";
import { useNavigate } from "react-router";
import { FieldRules } from "../../constants/field-rules";

function SignUp() {
  const navigate = useNavigate();

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm<SignUpRequest>({
    defaultValues: {
      firstName: "",
      email: "",
      password: "",
      terms: false,
      receiveMail: false,
    },
  });
  const onSubmit = async (data: SignUpRequest) => {
    try {
      const result = await authApi.signUp(data);
      if (result.isSuccess) navigate(ROUTES.SignIn);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <Container maxWidth="xs" sx={{ mt: 6 }}>
      <Typography
        component="div"
        variant="h3"
        mb={6}
        fontWeight={"400"}
        textAlign={"center"}
      >
        Sign Up
      </Typography>
      <Box
        component="form"
        onSubmit={handleSubmit(onSubmit)}
        display={"flex"}
        flexDirection={"column"}
        gap={2}
      >
        <Controller
          name="email"
          control={control}
          rules={{
            required: "Email is required",
            pattern: {
              value: FieldRules.EMAIL_REGEX,
              message: "Email is not correct format",
            },
          }}
          render={({ field }) => (
            <TextField
              {...field}
              label="Email"
              fullWidth
              placeholder="your@email.com"
              autoComplete="email"
              variant="standard"
              error={!!errors.email}
              helperText={errors.email?.message}
            />
          )}
        ></Controller>
        <Controller
          name="firstName"
          control={control}
          rules={{
            minLength: {
              value: FieldRules.NAME_MIN_LENGTH,
              message: `Name must be at least ${FieldRules.NAME_MIN_LENGTH} characters`,
            },
          }}
          render={({ field }) => (
            <TextField
              {...field}
              label="Name"
              autoComplete="name"
              fullWidth
              placeholder="Your name"
              variant="standard"
              error={!!errors.firstName}
              helperText={errors.firstName?.message}
            />
          )}
        ></Controller>

        <Controller
          name="password"
          control={control}
          rules={{
            required: "Password is required",
            minLength: {
              value: FieldRules.PASSWORD_MIN_LENGTH,
              message: `Password must be at least ${FieldRules.PASSWORD_MIN_LENGTH} characters`,
            },
          }}
          render={({ field }) => (
            <TextField
              {...field}
              label="Password"
              fullWidth
              placeholder="••••••"
              type="password"
              autoComplete="new-password"
              variant="standard"
              error={!!errors.password}
              helperText={errors.password?.message}
            />
          )}
        ></Controller>
        <Box>
          <Controller
            name="terms"
            control={control}
            rules={{
              required: "You have to agree with the terms of use",
            }}
            render={({ field }) => (
              <FormControlLabel
                control={
                  <Checkbox {...field} checked={field.value} color="primary" />
                }
                label={
                  <Typography variant="body2">
                    I agree to <Link href="#">privacy policy</Link> and{" "}
                    <Link href="#">terms of service</Link>
                  </Typography>
                }
              />
            )}
          ></Controller>
          <Controller
            name="receiveMail"
            control={control}
            render={({ field }) => (
              <FormControlLabel
                control={
                  <Checkbox {...field} checked={field.value} color="primary" />
                }
                label={
                  <Typography variant="body2">
                    I consent to receive marketing emails.
                  </Typography>
                }
              />
            )}
          ></Controller>
          {errors.terms && (
            <Typography variant="caption" component={"span"} color="error">
              {errors.terms.message}
            </Typography>
          )}
        </Box>
        <Button type="submit" fullWidth variant="contained" sx={{ mb: 2 }}>
          Sign up
        </Button>
      </Box>
      <Box display={"flex"} justifyContent={"space-between"}>
        <Typography sx={{ textAlign: "center" }}>
          Already have an account?
        </Typography>
        <Link
          href={ROUTES.SignIn}
          sx={{ alignSelf: "center", fontSize: "1rem" }}
        >
          Sign in
        </Link>
      </Box>
    </Container>
  );
}

export default SignUp;
