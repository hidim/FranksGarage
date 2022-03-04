import React from 'react';
import { render, screen } from '@testing-library/react';
import Footer from './footer';

test('renders fraks garage footer', () => {
  render(<Footer />);
  const linkElement = screen.getByText(/Frank's Garage/i);
  expect(linkElement).toBeInTheDocument();
});
