import {
  TextField,
  Typography,
  Box,
  Button,
  Link,
  Container,
  InputAdornment,
  IconButton,
} from "@mui/material";
import { ROUTES } from "../../routes";
import { useNavigate } from "react-router";
import { authApi } from "../../apis/auth-api";
import { SignInRequest } from "../../models/auth-model";
import { LocalStorageKey } from "../../constants/local-storage";
import { Controller, useForm } from "react-hook-form";
import { FieldRules } from "../../constants/field-rules";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { useState } from "react";

function SignIn() {
  const navigate = useNavigate();

  const [showPassword, setShowPassword] = useState(false);
  const handleClickShowPassword = () => setShowPassword((show) => !show);

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm<SignInRequest>({
    defaultValues: {
      email: "",
      password: "",
      rememberMe: false,
    },
  });

  const onSubmit = async (data: SignInRequest) => {
    try {
      const result = await authApi.signIn(data);
      if (result.data) {
        localStorage.setItem(
          LocalStorageKey.ACCESS_TOKEN,
          result.data.accessToken
        );
        navigate(ROUTES.Home);
      }
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
        Sign In
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
              type={showPassword ? "text" : "password"}
              autoComplete="new-password"
              variant="standard"
              error={!!errors.password}
              helperText={errors.password?.message}
              slotProps={{
                input: {
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton
                        aria-label={
                          showPassword
                            ? "hide the password"
                            : "display the password"
                        }
                        onClick={handleClickShowPassword}
                      >
                        {showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  ),
                },
              }}
            />
          )}
        ></Controller>
        <Link
          href="/forgot-password"
          component="a"
          variant="body2"
          alignSelf={"flex-end"}
        >
          Forgot your password?
        </Link>
        <Button
          sx={{ mt: 1, mb: 2 }}
          type="submit"
          fullWidth
          variant="contained"
        >
          Sign in
        </Button>
      </Box>

      <Box component={"div"} display={"flex"} justifyContent={"space-between"}>
        <Typography sx={{ textAlign: "center" }}>
          Don't have an account?{" "}
        </Typography>
        <Link href={ROUTES.SignUp} alignSelf={"center"}>
          Sign up
        </Link>
      </Box>
    </Container>
  );
}

export default SignIn;
